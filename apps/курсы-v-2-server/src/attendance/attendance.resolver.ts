import * as graphql from "@nestjs/graphql";
import { AttendanceResolverBase } from "./base/attendance.resolver.base";
import { Attendance } from "./base/Attendance";
import { AttendanceService } from "./attendance.service";

@graphql.Resolver(() => Attendance)
export class AttendanceResolver extends AttendanceResolverBase {
  constructor(protected readonly service: AttendanceService) {
    super(service);
  }
}
