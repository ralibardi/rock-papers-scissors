// Errors corresponding to non-2XX HTTP statuses
export class BaseError extends Error {
  constructor(message?: string) {
    super(message);
    Object.setPrototypeOf(this, new.target.prototype);
  }
}
export class UnauthorizedError extends BaseError {
  public status = 401;
  public message = "Not Authorised";
}
export class ForbiddenError extends BaseError {
  public status = 403;
  public message = "Forbidden";
}
export class NotFoundError extends BaseError {
  public status = 404;
  public message = "Not found";
}

export class BadRequestError extends BaseError {
  public status = 400;
}

export class BadConnectionError extends BaseError {
  public status = 502;
  public message = "Something went wrong";
}
export class UnexpectedError extends BaseError {
  public message = "Something went wrong";
}

// Errors from specific API endpoints
