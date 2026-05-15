import type { RequestDto } from "../types";
import RequestRow from "./RequestRow";

type Props = {
    items: RequestDto[];
    role: "admin" | "user";
    onApprove: (id: string) => void;
    onReject: (id: string) => void;
    onView: (request: RequestDto) => void;
};

export default function RequestTable({
    items,
    role,
    onApprove,
    onReject,
    onView,
}: Props) {
    if (items?.length === 0) {
        return (
            <div className="bg-white rounded-2xl shadow-sm border border-gray-100 p-10 text-center">
                <div className="text-5xl mb-3">📭</div>
                <p className="text-gray-500 text-lg font-medium">
                    No requests yet
                </p>
                <p className="text-sm text-gray-400 mt-1">
                    Newly submitted requests will appear here.
                </p>
            </div>
        );
    }

    return (
        <div className="bg-white rounded-2xl shadow-lg border border-sky-100 overflow-hidden">
            {/* Header */}
            <div className="px-6 py-4 bg-linear-to-r from-sky-500 to-cyan-500">
                <h2 className="text-white text-xl font-bold">
                    Approval Requests
                </h2>
                <p className="text-sky-100 text-sm">
                    Manage and review submitted requests
                </p>
            </div>

            {/* Table */}
            <div className="overflow-x-auto">
                <table className="w-full">
                    <thead className="bg-sky-50">
                        <tr className="text-gray-700 text-sm uppercase tracking-wide">
                            <th className="p-4 text-left font-semibold">Title</th>
                            <th className="p-4 text-left font-semibold">Description</th>
                            <th className="p-4 text-left font-semibold">Status</th>
                            <th className="p-4 text-left font-semibold">Date Created</th>
                            <th className="p-4 text-right font-semibold">Action</th>
                        </tr>
                    </thead>

                    <tbody className="divide-y divide-gray-100">
                        {items?.map((item) => (
                            <RequestRow
                                key={item.id}
                                item={item}
                                role={role}
                                onApprove={onApprove}
                                onReject={onReject}
                                onView={onView}

                            />
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}