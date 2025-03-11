provider "aws" {
  region = "us-west-2"
}

resource "aws_instance" "iis_server" {
  ami           = "ami-0abcdef1234567890"  # Replace with a valid Windows Server AMI ID
  instance_type = "t3.medium"
  key_name      = "your-ssh-key"            # Replace with your SSH key pair name

  tags = {
    Name = "IIS-Synthetic-Login-Server"
  }

  provisioner "remote-exec" {
    inline = [
      "powershell.exe Install-WindowsFeature -Name Web-Server",
      "powershell.exe New-Item -Path 'C:\inetpub\wwwroot\SyntheticLogin' -ItemType Directory",
      "powershell.exe Invoke-WebRequest -Uri 'https://example.com/identity-app.zip' -OutFile 'C:\inetpub\wwwroot\identity-app.zip'",
      "powershell.exe Expand-Archive -Path 'C:\inetpub\wwwroot\identity-app.zip' -DestinationPath 'C:\inetpub\wwwroot\SyntheticLogin'",
      "powershell.exe Remove-Item 'C:\inetpub\wwwroot\identity-app.zip'",
      "powershell.exe iisreset"
    ]
  }

  connection {
    type        = "winrm"
    user        = "Administrator"
    password    = "your-secure-password"  # Replace with a secure method for handling passwords
    host        = self.public_ip
    https       = true
    insecure    = true
  }
}

output "instance_ip" {
  value = aws_instance.iis_server.public_ip
}
