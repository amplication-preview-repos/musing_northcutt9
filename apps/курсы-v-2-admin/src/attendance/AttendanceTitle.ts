import { Attendance as TAttendance } from "../api/attendance/Attendance";

export const ATTENDANCE_TITLE_FIELD = "id";

export const AttendanceTitle = (record: TAttendance): string => {
  return record.id?.toString() || String(record.id);
};
