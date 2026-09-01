import socket
from concurrent.futures import ThreadPoolExecutor, as_completed

def scan_port(target_ip, port):
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.settimeout(1)  
        result = s.connect_ex((target_ip, port))
        if result == 0:
            return port 
        
def read_standard_ports(filename):
    standard_ports = {}
    with open(filename, 'r') as file:
        for line in file:
            port, name = line.strip().split()
            standard_ports[int(port)] = name
    return standard_ports

def main():
    url = input("Enter the target website: ")
    try:
        target_ip = socket.gethostbyname(url)
    except socket.gaierror:
        print("Invalid website URL.")
        return

    standard_ports = read_standard_ports("ports.txt")
    cores = 4

    open_ports = []

    with ThreadPoolExecutor(max_workers=cores) as ex:
        futures = [ex.submit(scan_port, str(target_ip), port) for port in range(1, 65536)]
        for f in as_completed(futures):
            open_port = f.result()
            if open_port:
                port_name = standard_ports.get(open_port, "Unknown Port")
                open_ports.append((open_port, port_name))

    if open_ports:
        print("Open Ports:")
        for port, name in open_ports:
            print(f"Port: {port}\tService: {name}")
    else:
        print("No open ports found after scanning.")

if __name__ == "__main__":
    main()
