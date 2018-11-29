# rav1e_gui
A GUI to convert video files to AV1 using rav1e

![Screenshot](https://moisescardona.me/files/2018-11-28/2.PNG)

I wrote this software to test the rav1e software. Unfortunately, at the current state, rav1e is single-threaded. This GUI solves the issue and enable multithreading by converting and splitting the input video file into segments of the length specified by the user in y4m format and extracting the audio as a WAV file using ffmpeg. It then encodes each file using a CPU thread. After the encoding is finished, the WAV file is converted to Opus and the .ivf files are concatenated. Lastly, the .ivf and .opus files are merged into a .webm or .mkv container.

## Dependencies:

* You need my build of `opusenc.exe`. You can get it here: https://moisescardona.me/opusenc_compiles
* You need ffmpeg as found here: https://ffmpeg.zeranoe.com/builds/. Use the nightly builds. [Instructions here.](https://moisescardona.me/downloading_ffmpeg_rav1e_gui)
* You also need rav1e. [Builds here.](https://moisescardona.me/rav1e_compiles)

Written in Visual Basic .NET using Visual Studio 2017.

# Updated components builds:

Ocasionally, rav1e and opusenc gets updated. You can download the latest version of rav1e_gui with these updated tools included here: [https://moisescardona.me/rav1e_gui](https://moisescardona.me/rav1e_gui)

Enjoy!
