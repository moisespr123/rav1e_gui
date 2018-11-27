# rav1e_gui
A GUI to convert video files to AV1 using rav1e

![Screenshot](https://moisescardona.me/files/2018-11-20/rav1e%20GUI%20v1.2%202018-11-20.PNG)

I wrote this software to test the rav1e software. Unfortunately, at the current state, rav1e is single-threaded. This GUI solves the issue and enable multithreading by converting and splitting the input video file into 1-second segments y4m files and splitting the audio as a WAV file using ffmpeg. It then encodes each file using a CPU thread. After the encoding is finished, the WAV file is converted to Opus and the .ivf files are concatenated. Lastly, the .ivf and .opus files are merged into a .webm container.

## Dependencies:
* You need my build of `opusenc.exe`. You can get it here: https://moisescardona.me/opusenc_compiles

* You need ffmpeg as found here: https://ffmpeg.zeranoe.com/builds/. Use the nightly builds. [Instructions here.](https://moisescardona.me/downloading_ffmpeg_rav1e_gui)
* You also need rav1e. [Builds here.](https://moisescardona.me/rav1e_compiles)

Written in Visual Basic .NET using Visual Studio 2017.

Enjoy!
