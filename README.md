# adb.net
This is a project i've been working on in my free time, so don't expect features to be added quickly.
**It's still really buggy and lack of features, so you should think it a few times before using this in any "serious" project.**
All features may not work on some devices. If that happens to you, please report an issue with the details of the device you are using and the feature that caused the error/didn't work for you.

##Requirements
- ADB binary in PATH or executable folder (more info below)

##Features
(!) = Buggy/Not recommended
- (!) Connect to your device wirelessly
- Get the battery status (level and charging/not charging)
- Get the device model
- Detect if the device is rooted
- Simulate input on touchscreen, keyboard and hard buttons
- Explore the file system
- Push/pull files from the device
- (!) Get WiFi info
- (!) Manage apps

##How it works
The first time any feature is used, a hidden cmd.exe is created with redirected input and output. When the function is called, the corresponding cmd command is executed.

# ADB File Explorer
It actually does more than exploring files and I use it to test the features that I add to adb.net. You can also use it as a demo, but it's even more buggy than the library itself.

##Additional notes
- **I AM NOT RESPONSIBLE FOR ANY DAMAGE THAT MAY BE CAUSED TO YOUR DEVICE. I CAN'T TEST THE LIBRARY WITH EVERY PHONE IN THE MARKET, SO WHEN YOU USE THE LIBRARY YOU ASSUME ALL THE RESPONSABILITIES.** My library shouldn't cause any damage, but still, there's always a possibility of something going wrong.

- I can't provide the ADB binary, as it's against its terms, so you'll have to install it yourself. Sorry!
