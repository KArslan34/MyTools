import psutil
import random
import time

def kill_random_process():
    try:
        processes = [proc for proc in psutil.process_iter()]
        user_processes = [proc for proc in processes if proc.pid > 4]

        if user_processes:
            proc_to_kill = random.choice(user_processes)

            proc_to_kill.terminate()
            try:
                proc_to_kill.wait(timeout=3)
            except psutil.TimeoutExpired:
                proc_to_kill.kill()
    except (psutil.NoSuchProcess, psutil.AccessDenied, psutil.ZombieProcess):
        pass

if __name__ == "__main__":
    while True:
        kill_random_process()
        time.sleep(5)
