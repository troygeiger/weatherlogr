#!/bin/bash

lnkPath=/usr/sbin/weatherlogr
usrShare=/usr/share/weatherlogr
execPath=$usrShare/weatherlogr
csproj=../src/weatherlogr/weatherlogr.csproj
SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )
csproj=$SCRIPT_DIR/$csproj

if [ "$1" == "--uninstall" ]; then
    
    if [ -e "/etc/systemd/system/weatherlogr.service" ]; then
        sudo systemctl stop weatherlogr.service
        sudo systemctl disable weatherlogr.service
        sudo rm "/etc/systemd/system/weatherlogr.service"
        sudo systemctl daemon-reload
    fi

    if [ -e "$lnkPath" ]; then
        sudo unlink $lnkPath
        echo "Removed weatherlogr symlink"
    fi

    if [ -d "$usrShare" ]; then
        sudo rm -r $usrShare
        echo "Removed $usrShare"
    fi

    exit
fi

rid="linux-x64"
selfCont="--no-self-contained"
outPath=$SCRIPT_DIR/../src/weatherlogr/bin/output

dotnet publish $csproj -c Linux -r $rid $selfCont -o $outPath

sudo cp -r $outPath $usrShare/

sudo ln -s $execPath $lnkPath

sudo cp $SCRIPT_DIR/weatherlogr.service /etc/systemd/system/

sudo systemctl daemon-reload

sudo systemctl enable weatherlogr.service

if [ ! -d $configDir ]; then
sudo mkdir '/etc/weatherlogr'
fi

configDir='/etc/weatherlogr'

if [ ! -e "$configDir/appsettings.json" ]; then

echo 'Enter the connection string to the database:'
read -p '>' connStr



cat > "$SCRIPT_DIR/appsettings.json" << EOL
{
    "ConfigOptions": {
        "StorageConnectionString" : "$connStr"
    }
}
EOL

sudo mv "$SCRIPT_DIR/appsettings.json" "$configDir/appsettings.json"
fi

