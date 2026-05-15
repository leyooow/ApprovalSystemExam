import type { RequestDto } from "../types";
import BaseModal from "./Modal";

type Props = {
    open: boolean;
    onClose: () => void;
    request: RequestDto | null;
};

export default function ViewRequestModal({
    open,
    onClose,
    request,
}: Props) {
    if (!request) return null;

    return (
        <BaseModal
            open={open}
            title="Request Details"
            onClose={onClose}
            cancelText="Close"
        >
            <div className="space-y-5">

                {/* Title */}
                <div>
                    <p className="mb-1 text-sm font-medium text-gray-500">
                        Title
                    </p>

                    <div className="rounded-xl bg-gray-50 p-3 text-gray-800">
                        {request.title}
                    </div>
                </div>

                {/* Description */}
                <div>
                    <p className="mb-1 text-sm font-medium text-gray-500">
                        Description
                    </p>

                    <div className="rounded-xl bg-gray-50 p-3 text-gray-800">
                        {request.description}
                    </div>
                </div>

                {/* Details */}
                <div className="grid grid-cols-2 gap-4">


                    <div>
                        <p className="mb-1 text-sm font-medium text-gray-500">
                            Status
                        </p>

                        <div className="rounded-xl bg-gray-50 p-3 text-gray-800">
                            {request.status}
                        </div>
                    </div>

                    <div>
                        <p className="mb-1 text-sm font-medium text-gray-500">
                            Reviewed By
                        </p>

                        <div className="rounded-xl bg-gray-50 p-3 text-gray-800">
                            {request.reviewedBy || "-"}
                        </div>
                    </div>


                </div>
                <div>
                    <p className="mb-1 text-sm font-medium text-gray-500">
                        Date Created
                    </p>

                    <div className="rounded-xl bg-gray-50 p-3 text-gray-800">
                        {new Date(request.dateCreated).toLocaleString()}
                    </div>
                </div>

                {/* Rejection Reason */}
                {request.rejectionReason && (
                    <div>
                        <p className="mb-1 text-sm font-medium text-red-500">
                            Rejection Reason
                        </p>

                        <div className="rounded-xl border border-red-100 bg-red-50 p-3 text-red-700">
                            {request.rejectionReason}
                        </div>
                    </div>
                )}
            </div>
        </BaseModal>
    );
}