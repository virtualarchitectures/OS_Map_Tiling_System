# OS Map Tiling System
Tiling System for Unity using OS Open Raster Tiles

![OSMapFlightSim](images/OSMapFlightSim.PNG)

## Contents
This Unity project includes the following components:
- A map tile prefab
- The script `MapController.cs` which instantiates map tiles in the corrrect position using OS National Grid coordinates and applies the correct OS open raster tile as a texture.
- A reference file `TileCoordinates.csv` which provides bottom left (south west) coordinate for each map tile.
- An FME workspace `MapTileBoundsExtractor.fmw` which can be used to read the coordinates from GeoTIFF files and export them to a CSV.

## Use

1. To use this package you will need to download your own copies of the [OS Vector Map District](https://www.ordnancesurvey.co.uk/business-and-government/products/vectormap-district.html) raster tiles for the TQ grid square.
2. Downloaded tiles should be placed in the project folder `Assets/Resources/MapTiles`.
3. Open the 'MapTiler' scene in Unity and press play.
4. The MapController script will read the GeoTIFF tiles placed in the Recources folder and instantiate textured maptile prefabs according to OSGB eastings and northings held in the 'TileCoordinates' reference file. The tiles are parented to a map container object and shifted to world origin (0,0,0) using a global offset.
5. The user can specify a particular OSGB coordinate that will be used as the Unity world origin. This is currently set to the easting `X = 537904` and northing `Y = 184041` in the Unity inspector.

This package can be used with Unity [Standard Assets](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351).

**Note:** The 'TileCoordinates.csv' file currently included in this package only provides coordinates for the TQ grid square of the British National Grid. This covers the majority of London and the region extending to the South of England. To test the package download that region first.

## Obtaining Coordinates for the rest of the UK
If you wish to include other areas of the UK you would need to use a GIS to prepare your own coordinate file. Alternatively you can use the FME workspace `MapTileBoundsExtractor.fmw` included in this project to extract coordinates from downloaded OS map tiles in the GeoTIFF format. To use the workspace you can download the [FME Desktop](https://www.safe.com/) by Safe Software which is free to use for non-commercial purposes with a trial or personal licence.

## Acknowledgements
This project is linked to research at CASA funded by the [Engineering and Physical Science Research Council (EPSRC)](https://epsrc.ukri.org/) and [Ordnance Survey (OS)](https://www.ordnancesurvey.co.uk/), the national mapping agency for Great Britain. 
