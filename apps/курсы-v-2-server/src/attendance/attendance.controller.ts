import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { AttendanceService } from "./attendance.service";
import { AttendanceControllerBase } from "./base/attendance.controller.base";

@swagger.ApiTags("attendances")
@common.Controller("attendances")
export class AttendanceController extends AttendanceControllerBase {
  constructor(protected readonly service: AttendanceService) {
    super(service);
  }
}
