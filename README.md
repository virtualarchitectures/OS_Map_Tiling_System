# OS Map Tiling System
Tiling System for Unity using OS Open Raster Tiles

![OSMapFlightSim](images/OSMapFlightSim.PNG)

## Contents
Project includes a map tile prefab, a preporocessed reference CSV of tile names and coordinates (OSGB), and a script to tile prefabs according to OS National Grid coordinates and apply OS open raster tiles as textures. Tiles are instantiated according to OSGB eastings and northings, parented to a map container object, and then shifted close to world origin (0,0,0) using a global offset. 

## Data
Uses Free Download of [OS Vector Map District](https://www.ordnancesurvey.co.uk/business-and-government/products/vectormap-district.html) raster tiles.

Downloaded tiles should be placed in the project foler `Assets/Resources/MapTiles`.
