import { FunctionComponent, ReactElement } from "react";

export const NavBar: FunctionComponent = (): ReactElement => {
  return (
    <>
      <nav className="navbar justify-between">
        <div className="container">
          <h1 className="site-title">Weather Monitor</h1>
          <ul className="display-f">
            <li className="ml-1 text-hover-secondary">
              <a
                href="https://www.linkedin.com/in/fabioqueiroz/"
                target="_blank"
              >
                About Me
              </a>
            </li>
          </ul>
        </div>
      </nav>
    </>
  );
};
