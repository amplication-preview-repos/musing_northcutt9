import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { AttendanceServiceBase } from "./base/attendance.service.base";

@Injectable()
export class AttendanceService extends AttendanceServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
