from __future__ import print_function
import httplib2
import os

from apiclient import discovery
from oauth2client import client
from oauth2client import tools
from oauth2client.file import Storage

try:
    import argparse
    flags = argparse.ArgumentParser(parents=[tools.argparser]).parse_args()
except ImportError:
    flags = None

# If modifying these scopes, delete your previously saved credentials
# at ~/.credentials/sheets.googleapis.com-python-quickstart.json
SCOPES = 'https://www.googleapis.com/auth/spreadsheets.readonly'
CLIENT_SECRET_FILE = 'client_secret.json'
APPLICATION_NAME = 'Google Sheets API Python Quickstart'


def get_credentials():
    """Gets valid user credentials from storage.

    If nothing has been stored, or if the stored credentials are invalid,
    the OAuth2 flow is completed to obtain the new credentials.

    Returns:
        Credentials, the obtained credential.
    """
    home_dir = os.path.expanduser('~')
    credential_dir = os.path.join(home_dir, '.credentials')
    if not os.path.exists(credential_dir):
        os.makedirs(credential_dir)
    credential_path = os.path.join(credential_dir,
                                   'sheets.googleapis.com-python-quickstart.json')

    store = Storage(credential_path)
    credentials = store.get()
    if not credentials or credentials.invalid:
        flow = client.flow_from_clientsecrets(CLIENT_SECRET_FILE, SCOPES)
        flow.user_agent = APPLICATION_NAME
        if flags:
            credentials = tools.run_flow(flow, store, flags)
        else: # Needed only for compatibility with Python 2.6
            credentials = tools.run(flow, store)
        print('Storing credentials to ' + credential_path)
    return credentials

def main():
    """Shows basic usage of the Sheets API.

    Creates a Sheets API service object and prints the names and majors of
    students in a sample spreadsheet:
    https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
    """
    credentials = get_credentials()
    http = credentials.authorize(httplib2.Http())
    discoveryUrl = ('https://sheets.googleapis.com/$discovery/rest?'
                    'version=v4')
    service = discovery.build('sheets', 'v4', http=http,
                              discoveryServiceUrl=discoveryUrl)

    spreadsheetId = '1jXsiN9ZcTLnJXRkwhy0DILUVklWAdkwZiS2m0PU4zZI'
    rangeName = 'Base Set!A2:H'
    result = service.spreadsheets().values().get(
        spreadsheetId=spreadsheetId, range=rangeName).execute()
    values = result.get('values', [])

    unitList = open("baseUnitList.json", "w")
    id = 0

    if not values:
        print("No data found.")
    else:
        unitList.write("{")
        unitList.write("\n    \"units\": [{ \n")
        for row in values:
            print(row[1])
            if row[1] != "Unit" and row[1] != "Commoner":
                continue
            print("Name, Influence, Methods")
            # Print columns A and E, which correspond to indices 0 and 4.
            print('%s, %s, %s' % (row[0], row[1], row[2]))
            unitList.write("        \"id\": \"Unit%s\"," % id)
            id = id+1
            unitList.write("\n        \"name\": \"%s\"," % row[0])
            unitList.write("\n        \"type\": \"%s\"," % row[1])
            unitList.write("\n        \"cost\": \"%s\"" % row[2])
            unitList.write("\n        \"might\": \"%s\"" % row[3])
            unitList.write("\n        \"money\": \"%s\"" % row[4])
            unitList.write("\n        \"magic\": \"%s\"" % row[5])
            unitList.write("\n        \"effect\": \"%s\"" % row[7])
            unitList.write("\n    },\n    {\n")

        unitList.write("\n    }\n  ]\n}")
    unitList.close()

if __name__ == '__main__':
    main()
