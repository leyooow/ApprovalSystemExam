import { useState } from "react";
import type { RequestFormDto } from "../types";
import BaseModal from "./Modal";
import { validateApprovalCreation } from "../utils/validation";

type Props = {
    open: boolean;
    onClose: () => void;
    onSubmit: (data: RequestFormDto) => void;
};

export default function CreateRequestModal({
    open,
    onClose,
    onSubmit,
}: Props) {
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [errors, setErrors] = useState<Record<string, string>>({});

    const handleSubmit = () => {
        const request: RequestFormDto = {
            title,
            description,
        };

        const errors = validateApprovalCreation({
            title,
            description,
        });

        if (Object.keys(errors).length > 0) {
            setErrors(errors); 
            return;
        }


        onSubmit(request);

        setTitle("");
        setDescription("");
        setErrors({})
        onClose();
    };

    return (
        <BaseModal
            open={open}
            title="New Request"
            onClose={onClose}
            onSubmit={handleSubmit}
            submitText="Submit Request"
            submitDisabled={!title || !description}
        >
            <div className="space-y-4">
                <input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder="Request title"
                    className="w-full rounded-xl border border-gray-200 p-3 outline-none transition focus:border-sky-400 focus:ring-4 focus:ring-sky-100"
                />
                
                {errors.title && (
                    <p className="text-red-500 text-xs">{errors.title}</p>
                )}

                <textarea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    placeholder="Request description"
                    className="min-h-30 w-full rounded-xl border border-gray-200 p-3 outline-none transition focus:border-sky-400 focus:ring-4 focus:ring-sky-100"
                />

                {errors.title && (
                    <p className="text-red-500 text-xs">{errors.description}</p>
                )}

            </div>
        </BaseModal>
    );
}

