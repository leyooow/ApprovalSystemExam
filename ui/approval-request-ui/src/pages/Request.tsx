import { useEffect, useState } from "react";

import type { RequestDto, RequestFormDto } from "../types";

import Header from "../components/Header";
import RequestTable from "../components/RequestTable";
import Toast from "../components/Toast";

import { requestApi } from "../api/requestApi";
import CreateRequestModal from "../components/CreateRequestModal";
import RejectModal from "../components/RejectModal";
import ViewRequestModal from "../components/ViewRequestModal";

export default function Request() {
    const [requestData, setRequestData] = useState<RequestDto[]>([]);
    const [role, setRole] = useState<"admin" | "user">("admin");
    const [showModal, setShowModal] = useState(false);
    const [toast, setToast] = useState("");

    const [showRejectModal, setShowRejectModal] = useState(false);
    const [selectedRequestId, setSelectedRequestId] = useState("");

    const [showViewModal, setShowViewModal] = useState(false);
    const [selectedRequest, setSelectedRequest] = useState<RequestDto | null>(null);

    useEffect(() => {
        loadRequests();
    }, []);


    const loadRequests = async () => {
        try {
            const response = await requestApi.getAll();

            // Because your API returns PagedResponse<RequestDto>
            setRequestData(response.items);

        } catch (error) {
            console.error(error);
            setToast("Failed to load requests");
        }
    };

    const createItem = async (
        data: Omit<RequestFormDto, "id" | "status" | "dateCreated">
    ) => {
        try {
            await requestApi.create(data);

            await loadRequests();

            setShowModal(false);
            setToast("Request submitted!");
        } catch (error) {
            console.error(error);
            setToast("Failed to create request");
        }
    };

    const handleApprove = async (id: string) => {
        try {
            await requestApi.approve(id, {
                reviewedBy: "Admin",
                remarks: "Approved successfully",
            });

            await loadRequests();

            setToast("Approved!");
        } catch (error) {
            console.error(error);
            setToast("Failed to approve request");
        }
    };

    const handleReject = async (id: string) => {
        setSelectedRequestId(id);
        setShowRejectModal(true);
    };

    const handleView = (request: RequestDto) => {
        setSelectedRequest(request);
        setShowViewModal(true);
    };

    const confirmReject = async (reason: string) => {
        try {
            await requestApi.reject(selectedRequestId, {
                reviewedBy: "Admin",
                remarks: reason,
            });

            await loadRequests();

            setShowRejectModal(false);
            setSelectedRequestId("");

            setToast("Rejected!");
        } catch (error) {
            console.error(error);
            setToast("Failed to reject request");
        }
    };
    return (
        <div className="min-h-screen bg-linear-to-br from-blue-50 via-sky-50 to-cyan-50 p-6">
            <Header
                role={role}
                setRole={setRole}
                onNew={() => setShowModal(true)}
            />

            <RequestTable
                items={requestData}
                role={role}
                onApprove={handleApprove}
                onReject={handleReject}
                onView={handleView}
            />

            <CreateRequestModal
                open={showModal}
                onClose={() => setShowModal(false)}
                onSubmit={createItem}
            />

            <ViewRequestModal
                open={showViewModal}
                onClose={() => setShowViewModal(false)}
                request={selectedRequest}
            />

            <RejectModal
                open={showRejectModal}
                onClose={() => setShowRejectModal(false)}
                onSubmit={confirmReject}
            />


            <Toast
                message={toast}
                onClose={() => setToast("")}
            />
        </div>
    );
}