# CWT_dev_server
### A prototype/toy used for reverse engineering the Cube World (Release) packets.

## Warning!
<b>This is not an actual server that you can play Cube World on!</b> This project's sole purpose is reverse engineering and documenting the packet protocol only. It should not be used by anybody for any other purpose.

## Build notes
As Steamworks.NET doesn't have a nuget package (and to avoid commiting binaries to git), you will have to download the [standalone 13.0.0 release](https://github.com/rlabrecque/Steamworks.NET/releases) and extract the files from `Windows-x64` into the `CWT_dev_server/steamworks_net_libs` folder before building.


## License notes
Although I licenced this code under MIT, I took a zlib helper class from [LastExceed/CubeworldNetworking](https://github.com/LastExceed/CubeworldNetworking/blob/mas##ter/Utilities/zlib.cs) which has no license listed, as such the license for that code is ambiguous.
