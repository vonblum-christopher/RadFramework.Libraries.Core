#!/bin/sh
cd ..
CurrentUser=$USER
sudo chown $CurrentUser . -R
cd RadFramework
echo "$CurrentUser owns the project now."
