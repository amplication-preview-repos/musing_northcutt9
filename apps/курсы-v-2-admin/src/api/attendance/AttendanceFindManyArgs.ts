import { AttendanceWhereInput } from "./AttendanceWhereInput";
import { AttendanceOrderByInput } from "./AttendanceOrderByInput";

export type AttendanceFindManyArgs = {
  where?: AttendanceWhereInput;
  orderBy?: Array<AttendanceOrderByInput>;
  skip?: number;
  take?: number;
};
