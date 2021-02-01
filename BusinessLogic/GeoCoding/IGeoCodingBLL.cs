using static ViewModels.WeatherModels.GeoCodingModel;

namespace BusinessLogic.GeoCoding
{
    public interface IGeoCodingBLL
    {
        Coordinates GetCoordinates(string address);
    }
}
