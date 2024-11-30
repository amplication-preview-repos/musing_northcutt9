import { Course as TCourse } from "../api/course/Course";

export const COURSE_TITLE_FIELD = "id";

export const CourseTitle = (record: TCourse): string => {
  return record.id?.toString() || String(record.id);
};
