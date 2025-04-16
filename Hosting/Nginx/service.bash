# 1. create service file
cd /etc/systemd/system
sudo touch myservice.service
sudo nano myservice.service
# write configs...

# 2. turn on service
sudo systemctl enable myservice.service
sudo systemctl start myservice.service

# 3. check
sudo systemctl status myservice.service
sudo journalctl -fu myservice.service