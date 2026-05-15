import type { ReactNode } from "react";

type Props = {
  open: boolean;
  title: string;
  children: ReactNode;
  onClose: () => void;
  onSubmit?: () => void;
  submitText?: string;
  cancelText?: string;
  submitDisabled?: boolean;
};

export default function BaseModal({
  open,
  title,
  children,
  onClose,
  onSubmit,
  submitText = "Submit",
  cancelText = "Cancel",
  submitDisabled = false,
}: Props) {
  if (!open) return null;

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/40 backdrop-blur-sm p-4">
      <div className="w-full max-w-md rounded-2xl bg-white shadow-2xl animate-in fade-in zoom-in-95">

        {/* Header */}
        <div className="border-b border-gray-100 px-6 py-4">
          <h2 className="text-xl font-bold text-gray-800">
            {title}
          </h2>
        </div>

        {/* Body */}
        <div className="px-6 py-5">
          {children}
        </div>

        {/* Footer */}
        <div className="flex justify-end gap-3 border-t border-gray-100 px-6 py-4">
          <button
            onClick={onClose}
            className="rounded-xl border border-gray-200 px-4 py-2 text-gray-600 transition hover:bg-gray-100"
          >
            {cancelText}
          </button>

          {onSubmit && (
            <button
              onClick={onSubmit}
              disabled={submitDisabled}
              className="rounded-xl bg-sky-500 px-5 py-2 font-medium text-white transition hover:bg-sky-600 disabled:cursor-not-allowed disabled:opacity-50"
            >
              {submitText}
            </button>
          )}
        </div>
      </div>
    </div>
  );
}