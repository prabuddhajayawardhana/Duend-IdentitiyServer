export async function GetPopulateWeatherData() {
    const response = await fetch('weatherforecast');
    return await response.json();
}

