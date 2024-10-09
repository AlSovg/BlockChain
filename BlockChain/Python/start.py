from blockchain import BlockChain
import json

link_client = 'https://b1.ahmetshin.com/static/blockchain.py'

username = 'Alex'
password = 'Aa123456.'
init = BlockChain(username=username, password=password, base_url = 'https://b1.ahmetshin.com/restapi/')
init.get_version_file()










