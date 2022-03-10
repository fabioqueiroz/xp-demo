import { FunctionComponent, ReactElement } from "react";

interface CardInfo {
  cardTitle: string;
  output: string | number;
}

export const DisplayCard: FunctionComponent<CardInfo> = ({
  cardTitle,
  output,
}): ReactElement => {
  return (
    <>
      <div className="col-12-xs col-6-md col-6-lg">
        <div className="card p-0">
          <h3 className="card-title m-1">{cardTitle}</h3>

          <p className="m-1">{output}</p>
        </div>
      </div>
    </>
  );
};
