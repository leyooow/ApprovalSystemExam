export type RequestStatus = "Pending" | "Approved" | "Rejected";

export type RequestDto = {
  id: string;
  title: string;
  description: string;
  requestedBy: string;
  status: number;
  rejectionReason: string
  createdBy: string;
  dateCreated: string;
  reviewedBy: string;
  dateReviewed: string;
};


export type RequestFormDto = {
  title: string;
  description: string;
};


