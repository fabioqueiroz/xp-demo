import { ServiceHandlingInterface } from '../shared/service-handling';

export const repository = {
    get: async <T>(url: RequestInfo): Promise<ServiceHandlingInterface<T>> => {
      const response = await fetch(url, {
        headers: {
          'Content-Type': 'application/json'
        },
      }).catch((err) => {
        return createResponse(400, err);
      });
  
      const hasData = response?.ok ?? false;
      const result: ServiceHandlingInterface<T> = {
        data: hasData ? await response?.json() : undefined,
        error: !hasData,
        loading: false,
        status: response.status,
      };
      return result;
    },

    post: async <T>(url: RequestInfo, data: string): Promise<ServiceHandlingInterface<T>> => {
        const response = await fetch(url, {
          method: 'post',
          headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            Accept: 'application/json',
          },
          mode: 'cors',
          body: data,
        }).catch((err) => {
          return createResponse(400, err);
        });
        const hasData = response.ok;
        const result: ServiceHandlingInterface<T> = {
          data: hasData ? await response?.json() : undefined,
          error: !hasData,
          loading: false,
          status: response.status,
        };
        return result;
    }
}

const createResponse = (status: number, err?: string): Response => {
    const strFunc: Promise<string> = new Promise((resolve) => {
      resolve(err ?? '');
    });

    return {
      headers: new Headers(),
      ok: false,
      redirected: false,
      status: status,
      statusText: '',
      type: 'default',
      url: '',
      clone: (): Response => {
        return null!;
      },
      bodyUsed: false,
      body: null,
      arrayBuffer: null!,
      blob: null!,
      formData: null!,
      json: () => strFunc,
      text: () => strFunc,
    };
  };