import type { JSX } from "react";
import type { RequestDto } from "../types";

type Props = {
  item: RequestDto;
  role: "admin" | "user";
  onApprove: (id: string) => void;
  onReject: (id: string) => void;
  onView: (request: RequestDto) => void;
};

export default function RequestRow({ item, role, onApprove, onReject, onView }: Props) {
  const isPending = item.status === 1;

  const statusUI: Record<number, JSX.Element> = {
    1: (
      <span className="bg-yellow-100 text-yellow-700 px-2 py-1 rounded">
        Pending
      </span>
    ),
    2: (
      <span className="bg-green-100 text-green-700 px-2 py-1 rounded">
        Approved
      </span>
    ),
    3: (
      <span className="bg-red-100 text-red-700 px-2 py-1 rounded">
        Rejected
      </span>
    ),
  };

  return (
    <tr
      onClick={() => onView(item)}
      className="cursor-pointer transition hover:bg-sky-50"
    >
      <td className="p-4">{item.title}</td>
      <td className="p-4">{item.description}</td>
      <td className="p-4">{statusUI[item.status]}</td>
      <td className="p-4">
        {new Date(item.dateCreated).toLocaleDateString()}
      </td>


      <td className="p-4 text-right align-middle">
        {isPending && role === "admin" ? (
          <div className="flex items-center justify-end gap-2">
            <button
              onClick={(e) => {
                e.stopPropagation();
                onApprove(item.id);
              }}
              className="bg-green-500 hover:bg-green-600 text-white text-sm font-medium px-4 py-1.5 rounded-md shadow-sm transition"
            >
              Approve
            </button>

            <button
              onClick={(e) => {
                e.stopPropagation();
                onReject(item.id);
              }}
              className="bg-red-500 hover:bg-red-600 text-white text-sm font-medium px-4 py-1.5 rounded-md shadow-sm transition"
            >
              Reject
            </button>
          </div>
        ) : (
          <span className="text-gray-400 text-sm">—</span>
        )}
      </td>

    </tr>
  );
}