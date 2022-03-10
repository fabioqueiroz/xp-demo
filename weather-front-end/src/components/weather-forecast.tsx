import { FunctionComponent, ReactElement, useState } from "react";
import { WeatherSearch } from "../models/weather-search-model";
import { DisplayCard } from "../components/display-card";
import { services } from "../services/services";

export const WeatherForecast: FunctionComponent = (): ReactElement => {
  const [weatherSearch, setWeatherSearch] = useState<WeatherSearch>();
  const [cityName, setCityName] = useState<string>("");
  const [typedValue, setTypedValue] = useState<string>("");

  const fetchWeatherData = async (city: string) => {
    const result = await services.getWeatherData(city);
    if (!!result) {
      setWeatherSearch(result.data);
    }
  };

  const onCitySearchChange = (event: any) => {
    setCityName(event.target.value);
    setTypedValue(event.target.value);
  };

  const handleClickSubmit = () => {
    fetchWeatherData(cityName);
    setTypedValue("");
  };

  const formatStringDate = (stringDate?: string) => {
    if (!stringDate) {
      return "";
    }
    const splittedDate = stringDate.split(" ");
    const date = splittedDate[0].split("-").reverse().join("/");
    const time = splittedDate[1].split(".")[0];
    return date + ", at " + time;
  };

  return (
    <>
      <div className="container">
        <h2 className="mb-2">Forecast data by city</h2>
        <div className="row justify-center mt-2">
          <input
            className="font-lg"
            type="text"
            placeholder="Enter city name"
            onChange={onCitySearchChange}
            value={typedValue}
          ></input>
        </div>
        <div className="row justify-center mt-2">
          <button
            className="btn-secondary text-white font-md"
            onClick={handleClickSubmit}
          >
            Search now!
          </button>
        </div>
        <div className="row gap-2">
          <DisplayCard cardTitle="City" output={weatherSearch?.city ?? ""} />
          <DisplayCard
            cardTitle="Region"
            output={weatherSearch?.region ?? ""}
          />
          <DisplayCard
            cardTitle="Country"
            output={weatherSearch?.country ?? ""}
          />
          <DisplayCard
            cardTitle="Local time"
            output={formatStringDate(weatherSearch?.localTime)}
          />
          <DisplayCard
            cardTitle="Temperature (C)"
            output={weatherSearch?.temperatureC ?? ""}
          />
          <DisplayCard
            cardTitle="Temperature (F)"
            output={weatherSearch?.temperatureF ?? ""}
          />
          <DisplayCard
            cardTitle="Sunrise"
            output={weatherSearch?.sunrise ?? ""}
          />
          <DisplayCard
            cardTitle="Sunset"
            output={weatherSearch?.sunset ?? ""}
          />
        </div>
      </div>
    </>
  );
};
