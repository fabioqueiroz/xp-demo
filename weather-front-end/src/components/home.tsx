import { FunctionComponent, ReactElement } from "react";
import { WeatherForecast } from "../components/weather-forecast";
import { NavBar } from "../components/navbar";

export const Home: FunctionComponent = (): ReactElement => {
  return (
    <>
      <NavBar />

      <div className="container mt-5">
        <div className="row justify-center">
          <div className="col-12-xs col-5-md">
            <h2>
              <div className="font-xxl">Local weather information </div>
              <div className="font-xxl text-secondary">
                Tracking a ship somewhere around the globe?
              </div>
            </h2>
            <p className="text-gray mt-2 mb-3">
              Get the latest forecast information for any city in the world!
            </p>
            <a
              href="#forecast"
              className="btn-outlined-secondary text-secondary text-hover-white"
            >
              Find out more
            </a>
          </div>
          <div className="col-12-xs col-5-md"></div>
        </div>
      </div>

      <section
        id="about"
        className="bg-secondary-light-9 mt-5 pt-4 pb-4"
      ></section>

      <section id="forecast" className="mt-5">
        <WeatherForecast />
      </section>

      <footer className="bg-gray-light-7 pt-3 pb-3 mt-5">
        <div className="container">Fabio Queiroz - 2022</div>
      </footer>
    </>
  );
};
