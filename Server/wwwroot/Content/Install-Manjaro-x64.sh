#!/bin/bash
HostName=
Organization=
GUID=$(cat /proc/sys/kernel/random/uuid)
UpdatePackagePath=""
InstallDir="/usr/local/bin/Raef Tech"
ETag=$(curl --head $HostName/Content/Raef Tech-Linux.zip | grep -i "etag" | cut -d' ' -f 2)
LogPath="/var/log/remotely/Agent_Install.log"

mkdir -p /var/log/remotely

Args=( "$@" )
ArgLength=${#Args[@]}

for (( i=0; i<${ArgLength}; i+=2 ));
do
    if [ "${Args[$i]}" = "--uninstall" ]; then
        systemctl stop remotely-agent
        rm -r -f $InstallDir
        rm -f /etc/systemd/system/remotely-agent.service
        systemctl daemon-reload
        exit
    elif [ "${Args[$i]}" = "--path" ]; then
        UpdatePackagePath="${Args[$i+1}"
    fi
done

if [ -z "$ETag" ]; then
    echo  "ETag is empty.  Aborting install." | tee -a $LogPath
    exit 1
fi

pacman -Sy
pacman -S dotnet-runtime-8.0 --noconfirm
pacman -S libx11 --noconfirm
pacman -S unzip --noconfirm
pacman -S libc6 --noconfirm
pacman -S libxtst --noconfirm
pacman -S xclip --noconfirm
pacman -S jq --noconfirm
pacman -S curl --noconfirm

if [ -f "$InstallDir/ConnectionInfo.json" ]; then
    SavedGUID=`cat "$InstallDir/ConnectionInfo.json" | jq -r '.DeviceID'`
    if [[ "$SavedGUID" != "null" && -n "$SavedGUID" ]]; then
        GUID="$SavedGUID"
    fi
fi

rm -r -f $InstallDir
rm -f /etc/systemd/system/remotely-agent.service

mkdir -p $InstallDir

if [ -z "$UpdatePackagePath" ]; then
    echo  "Downloading client." | tee -a $LogPath
    wget -q -O /tmp/Raef Tech-Linux.zip $HostName/Content/Raef Tech-Linux.zip
else
    echo  "Copying install files." | tee -a $LogPath
    cp "$UpdatePackagePath" /tmp/Raef Tech-Linux.zip
    rm -f "$UpdatePackagePath"
fi

unzip -o /tmp/Raef Tech-Linux.zip -d $InstallDir
rm -f /tmp/Raef Tech-Linux.zip
chmod +x $InstallDir/Raef Tech_Agent
chmod +x $InstallDir/Desktop/Raef Tech_Desktop

connectionInfo="{
    \"DeviceID\":\"$GUID\", 
    \"Host\":\"$HostName\",
    \"OrganizationID\": \"$Organization\",
    \"ServerVerificationToken\":\"\"
}"

echo "$connectionInfo" > $InstallDir/ConnectionInfo.json

curl --head $HostName/Content/Raef Tech-Linux.zip | grep -i "etag" | cut -d' ' -f 2 > $InstallDir/etag.txt

echo Creating service... | tee -a $LogPath

serviceConfig="[Unit]
Description=The Raef Tech agent used for remote access.

[Service]
WorkingDirectory=$InstallDir
ExecStart=$InstallDir/Raef Tech_Agent
Restart=always
StartLimitIntervalSec=0
RestartSec=10

[Install]
WantedBy=graphical.target"

echo "$serviceConfig" > /etc/systemd/system/remotely-agent.service

systemctl enable remotely-agent
systemctl restart remotely-agent

echo Install complete. | tee -a $LogPath