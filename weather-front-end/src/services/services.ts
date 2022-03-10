import { repository } from '../services/repository';
import { ServiceHandlingInterface } from '../shared/service-handling';
import { Config } from '../config/config';
import { WeatherSearch } from "../models/weather-search-model";

export const services = {
    getWeatherData:(city: string) : Promise<ServiceHandlingInterface<WeatherSearch>> => {
        return repository.get(`${Config.weatherService}WeatherForecast/GetWeatherForecast/${city}`);
    },
    // getWeatherData:(data: WeatherSearch) : Promise<ServiceHandlingInterface<WeatherSearch>> => {
    //     return repository.post(`${Config.weatherService}WeatherForecast/WeatherForecast/`, JSON.stringify(data));
    // }
}