import { useState } from "react";
import BaseModal from "./Modal";
import { validateApprovalRejection } from "../utils/validation";

type Props = {
    open: boolean;
    onClose: () => void;
    onSubmit: (rejectionReason: string) => void;
};

export default function RejectModal({
    open,
    onClose,
    onSubmit,
}: Props) {
    const [rejectionReason, setRejectionReason] = useState("");
    const [errors, setErrors] = useState<Record<string, string>>({});

    const handleSubmit = () => {
        const errors = validateApprovalRejection({
            rejectionReason,
        });

        if (Object.keys(errors).length > 0) {
            setErrors(errors);
            return;
        }

        onSubmit(rejectionReason);

        setRejectionReason("");
        onClose();
    };

    return (
        <BaseModal
            open={open}
            title="Reject Request"
            onClose={onClose}
            onSubmit={handleSubmit}
            submitText="Reject"
            submitDisabled={!rejectionReason}
        >
            <textarea
                value={rejectionReason}
                onChange={(e) => setRejectionReason(e.target.value)}
                placeholder="Enter rejection reason..."
                className="min-h-30 w-full rounded-xl border border-gray-200 p-3 outline-none transition focus:border-red-400 focus:ring-4 focus:ring-red-100"
            />
            {errors.rejectionReason && (
                <p className="text-red-500 text-xs">{errors.rejectionReason}</p>
            )}

        </BaseModal>
    );
}