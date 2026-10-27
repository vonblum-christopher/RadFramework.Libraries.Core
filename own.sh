#!/bin/sh
CurrentUser=$USER
sudo chown $CurrentUser . -R
echo "$CurrentUser owns the project now."
