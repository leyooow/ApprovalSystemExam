export function validateApprovalCreation(data: {
  title?: string;
  description?: string;
}) {
  const errors: Record<string, string> = {};

  if (!data.title || data.title.trim() === "") {
    errors.title = "Title is required";
  }

  if (!data.description || data.description.trim() === "") {
    errors.description = "Description is required";
  }

  if (data.title && data.title.length < 3) {
    errors.title = "Title must be at least 3 characters";
  }

  return errors;
}


export function validateApprovalRejection(data: {
  rejectionReason?: string;
}) {
  const errors: Record<string, string> = {};

  if (!data.rejectionReason) {
    errors.title = "Rejection Reason is required";
  }

  return errors;
}
