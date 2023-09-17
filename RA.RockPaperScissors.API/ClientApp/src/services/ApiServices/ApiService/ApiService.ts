import {
  BadRequestError,
  ForbiddenError,
  NotFoundError,
  UnauthorizedError,
  UnexpectedError,
} from "../../ApiErrors";

export default class ApiService<T> {
  baseUrl: string = `api`;
  /* Private methods */
  private defaultOptionsForMethod(method: string): RequestInit {
    return {
      credentials: "include",
      method: method,
    };
  }

  private makeHttpRequestWithoutBody(
    path: string,
    method: string
  ): Promise<unknown> {
    const url = `${this.baseUrl}${path}`;

    const requestHeaders = {
      Accept: "application/json",
      "Content-Type": "application/json",
    };

    return this.makeHttpRequest(url, {
      ...this.defaultOptionsForMethod(method),
      headers: requestHeaders,
    });
  }

  private makeHttpRequestWithBody(
    path: string,
    body: string,
    method: string
  ): Promise<unknown> {
    const url = `${this.baseUrl}${path}`;

    const requestHeaders = {
      Accept: "application/json",
      "Content-Type": "application/json",
    };
    const options: RequestInit = {
      ...this.defaultOptionsForMethod(method),
      headers: requestHeaders,
      body: body,
    };

    return this.makeHttpRequest(url, options);
  }

  private makeHttpRequest(
    url: RequestInfo,
    options: RequestInit
  ): Promise<Response> {
    return fetch(url, options).then((response) => {
      if (!response.ok) {
        return this.handleHttpError(response);
      }
      return response.status === 204 ? null : response.json();
    });
  }

  private async mapErrorsToReadableString(response: Response): Promise<string> {
    const { additionalDetails, errors = {} } = await response.json();
    const errorList = Object.keys(errors)
      .map((key) => errors[key])
      .flat()
      .concat(additionalDetails)
      .filter(Boolean);

    return errorList.length ? errorList.join(", ") : "Something went wrong.";
  }

  private async handleHttpError(response: Response): Promise<void> {
    switch (response.status) {
      case 400: {
        const errorsString = await this.mapErrorsToReadableString(response);
        throw new BadRequestError(errorsString);
      }
      case 401: {
        throw new UnauthorizedError();
      }
      case 403: {
        throw new ForbiddenError();
      }
      case 404: {
        throw new NotFoundError();
      }
      default:
        throw new UnexpectedError();
    }
  }

  /* Protected Methods */

  protected get(apiPath: string): Promise<T> {
    return this.makeHttpRequestWithoutBody(apiPath, "GET") as Promise<T>;
  }

  protected getMultiple(apiPath: string): Promise<T[]> {
    return this.makeHttpRequestWithoutBody(apiPath, "GET") as Promise<T[]>;
  }

  protected delete(path: string): Promise<void> {
    return this.makeHttpRequestWithoutBody(path, "DELETE") as Promise<void>;
  }

  protected add(path: string, body: string): Promise<T> {
    return this.makeHttpRequestWithBody(path, body, "POST") as Promise<T>;
  }

  protected addBulk(path: string, body: string): Promise<void> {
    return this.makeHttpRequestWithBody(path, body, "POST") as Promise<void>;
  }

  protected update(path: string, body: string): Promise<void> {
    return this.makeHttpRequestWithBody(path, body, "PUT") as Promise<void>;
  }

  protected updateBulk(path: string, body: string): Promise<void> {
    return this.makeHttpRequestWithBody(path, body, "PUT") as Promise<void>;
  }

  protected patch(path: string, body: string): Promise<T> {
    return this.makeHttpRequestWithBody(path, body, "PATCH") as Promise<T>;
  }
}
