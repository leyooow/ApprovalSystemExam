import api from "./axios";
import { ENDPOINTS } from "./endpoints";

export interface ApprovalActionDto {
  reviewedBy: string;
  remarks?: string;
}

export interface PaginationParams {
  pageNumber?: number;
  pageSize?: number;
}

export const requestApi = {
  // GET: /api/approval?pageNumber=1&pageSize=10
  getAll: async (params?: PaginationParams) => {
    const response = await api.get(ENDPOINTS.APPROVAL, {
      params: {
        pageNumber: params?.pageNumber ?? 1,
        pageSize: params?.pageSize ?? 10,
      },
    });

    return response.data;
  },

  // GET: /api/approval/{id}
  getById: async (id: string) => {
    const response = await api.get(
      `${ENDPOINTS.APPROVAL}/${id}`
    );

    return response.data;
  },

  // POST: /api/approval
  create: async (data: any) => {
    const response = await api.post(
      ENDPOINTS.APPROVAL,
      data
    );

    return response.data;
  },

  // PUT: /api/approval/{id}/approve
  approve: async (
    id: string,
    data: ApprovalActionDto
  ) => {
    const response = await api.put(
      `${ENDPOINTS.APPROVAL}/${id}/approve`,
      data
    );

    return response.data;
  },

  // PUT: /api/approval/{id}/reject
  reject: async (
    id: string,
    data: ApprovalActionDto
  ) => {
    const response = await api.put(
      `${ENDPOINTS.APPROVAL}/${id}/reject`,
      data
    );

    return response.data;
  },
};