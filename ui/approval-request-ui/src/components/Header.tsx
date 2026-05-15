type Props = {
  role: "admin" | "user";
  setRole: (role: "admin" | "user") => void;
  onNew: () => void;
};

export default function Header({ role, setRole, onNew }: Props) {
  return (
    <header className="flex items-center justify-between mb-5 p-4">
      
      {/* Left Section */}
      <div className="flex items-center gap-6">
        <h1 className="text-2xl font-semibold text-sky-600">
          Approval System
        </h1>

        {/* Role Selector */}
        <div className="flex items-center gap-2">
          <label className="text-sm text-gray-500">Role:</label>
          <select
            value={role}
            onChange={(e) => setRole(e.target.value as "admin" | "user")}
            className="border border-gray-300 px-3 py-1.5 rounded-md text-sm focus:outline-none focus:ring-2 focus:ring-sky-500"
          >
            <option value="admin">Admin</option>
            <option value="user">User</option>
          </select>
        </div>
      </div>

      {/* Right Section */}
      <button
        onClick={onNew}
        className="bg-sky-500 hover:bg-sky-600 text-white text-sm font-medium px-5 py-2 rounded-lg shadow-sm transition"
      >
        + New Request
      </button>
    </header>
  );
}
