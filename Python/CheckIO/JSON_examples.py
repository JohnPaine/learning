import json
from pprint import pprint

def test_1(data):
    print(json.dumps(data, sort_keys=True, indent=4))
    print(data['foo'])

def test_2(data):
    jsonData = json.loads(data)
    test_1(jsonData)
    pprint(jsonData[0])


if __name__ == '__main__':
    # test_1(['foo', {'bar': ('baz', None, 1.0, 2)}])
    test_2('["foo", {"bar":["baz", null, 1.0, 2]}]')