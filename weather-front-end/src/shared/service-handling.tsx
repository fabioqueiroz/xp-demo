export interface ServiceHandlingInterface<T> {
  data: T;
  loading: boolean;
  error: boolean | undefined;
  status?: number;
}
