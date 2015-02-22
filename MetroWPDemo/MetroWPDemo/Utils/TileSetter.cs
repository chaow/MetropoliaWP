
namespace MetroWPDemo.Utils
{
    public static class TileSetter
    {
        public static void CreateTiles(string mediumTileImage, string wideTileImage, string tileText)
        {
            Windows.Data.Xml.Dom.XmlDocument tileXML = new Windows.Data.Xml.Dom.XmlDocument();

            ////////////////////////////////////////////////////////
            // Find all the available tile template formats at:
            //      http://msdn.microsoft.com/en-us/library/windows/apps/Hh761491.aspx

            string tileString = "<tile>" +
              "<visual version=\"2\">" +
              "<binding template=\"TileSquare150x150PeekImageAndText04\" fallback=\"TileSquarePeekImageAndText04\">" +
                  "<image id=\"1\" src=\"" + mediumTileImage + "\" alt=\"alt text\"/>" +
                  "<text id=\"1\">" + tileText + "</text>" +
                "</binding>" +
                "<binding template=\"TileWide310x150ImageAndText01\" fallback=\"TileWideImageAndText01\">" +
                  "<image id=\"1\" src=\"" + wideTileImage + "\" alt=\"alt text\"/>" +
                  "<text id=\"1\">" + tileText + "</text>" +
                "</binding>" +
              "</visual>" +
            "</tile>";
            tileXML.LoadXml(tileString);

            // Create tile notification
            Windows.UI.Notifications.TileNotification newTile 
                = new Windows.UI.Notifications.TileNotification(tileXML);

            // Send the XML notifications to tile updater
            Windows.UI.Notifications.TileUpdater updateTiler 
                = Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication();
            updateTiler.EnableNotificationQueue(false);
            updateTiler.Update(newTile);

        }
    }
}
