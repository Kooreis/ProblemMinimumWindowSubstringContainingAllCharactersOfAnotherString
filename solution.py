Here is a Python console application that solves the problem:

```python
from collections import defaultdict

def min_window(s, t):
    if not t or not s:
        return ""

    dict_t = defaultdict(int)
    for c in t:
        dict_t[c] += 1

    required = len(dict_t)

    l, r = 0, 0

    formed = 0

    window_counts = defaultdict(int)

    ans = float("inf"), None, None

    while r < len(s):

        character = s[r]
        window_counts[character] += 1

        if character in dict_t and window_counts[character] == dict_t[character]:
            formed += 1

        while l <= r and formed == required:
            character = s[l]

            if r - l + 1 < ans[0]:
                ans = (r - l + 1, l, r)

            window_counts[character] -= 1
            if character in dict_t and window_counts[character] < dict_t[character]:
                formed -= 1

            l += 1    

        r += 1    
    return "" if ans[0] == float("inf") else s[ans[1] : ans[2] + 1]

def main():
    s = input("Enter the string: ")
    t = input("Enter the characters: ")
    print("Minimum window substring: ", min_window(s, t))

if __name__ == "__main__":
    main()
```

This console application first takes the string and the characters as input from the user. Then it finds the minimum window substring that contains all characters of the second string and prints it. If no such window exists, it prints an empty string.