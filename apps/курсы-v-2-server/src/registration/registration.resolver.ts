import * as graphql from "@nestjs/graphql";
import { RegistrationResolverBase } from "./base/registration.resolver.base";
import { Registration } from "./base/Registration";
import { RegistrationService } from "./registration.service";

@graphql.Resolver(() => Registration)
export class RegistrationResolver extends RegistrationResolverBase {
  constructor(protected readonly service: RegistrationService) {
    super(service);
  }
}
