#!/bin/bash
set -e
set -x

rm -rf "/Applications/Google Chrome.app"
cd /tmp
curl -o ./googlechrome.dmg -k https://dl.google.com/chrome/mac/stable/GGRO/googlechrome.dmg
hdiutil attach -nobrowse -quiet -noautofsck -noautoopen -mountpoint /Volumes/googlechrome.dmg ./googlechrome.dmg
cp -rf "/Volumes/googlechrome.dmg/Google Chrome.app" /Applications
hdiutil detach /Volumes/googlechrome.dmg
rm -rf /tmp/googlechrome.dmg
/Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --version
