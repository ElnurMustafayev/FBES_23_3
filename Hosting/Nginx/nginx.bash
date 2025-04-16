# 1. install nginx
sudo apt update
sudo apt install -y nginx

# 2. check
sudo service nginx status
# open IP in browser

# 3. write new nginx configuration
cd /etc/nginx/sites-available
sudo touch myconf.conf
sudo nano myconf.conf
# write configs...
sudo ln -s /etc/nginx/sites-available/myconf.conf /etc/nginx/sites-enabled

# 4. restart nginx & apply new configuration
sudo service nginx restart