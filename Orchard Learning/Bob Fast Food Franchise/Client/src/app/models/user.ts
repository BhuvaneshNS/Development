import { UserRole } from './user-role';

export interface User {
  personId: number;
  personName: string;
  password: string;
  emailId: string;
  personCity: string;
  roleId: number;
  role: UserRole;
}
