import time
import subprocess
import random
import string

def random_hizmet_adi():
    return ''.join(random.choices(string.ascii_letters + string.digits, k=8))

def stop(hizmet_adi):
    try:
        subprocess.run(["net", "stop", hizmet_adi], check=True)
    except subprocess.CalledProcessError as e:
        pass

def ana_program(bekleme_suresi):
    hizmet_adi = random_hizmet_adi()
    
    time.sleep(bekleme_suresi)
    
    stop(hizmet_adi)

if __name__ == "__main__":
    bekleme_suresi = 60
    
    ana_program(bekleme_suresi)

