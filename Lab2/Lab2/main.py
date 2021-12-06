str1_ciphered = "280dc9e47f3352c307f6d894ee8d534313429a79c1d8a6021f8a8eabca919cfb685a0d468973625e757490daa981ea6b"
str2_ciphered = "2f0cdfe464344e8650edc59daac3504b1710d56b89dce5011e8c90f6"
# str2_ciphered = "2f0cdfe46d35498602e9df91f9c842061d569a6adbd8e701579397ac82d093f12c09034696787f0a"


def create_duplets(str):
    result = []
    for index, char in enumerate(str):
        if index < len(str) - 1 and index % 2 == 0:
            result.append(f"{char}{str[index+1]}")
    return result
    
    
result1 = create_duplets(str1_ciphered)
result2 = create_duplets(str2_ciphered)

def xor(arr1, arr2):
    answer = ""
    for byte_str1, byte_str2 in zip(arr1, arr2):
        byte1 = int(byte_str1, 16)
        byte2 = int(byte_str2, 16)
        xor_bytes = hex(byte1 ^ byte2)[2:]
        answer += f"{xor_bytes}".rjust(2, '0')
    return answer

xor_ciphered_strings = xor(result1, result2)

supposed_word = "And lose the name of action."

duplets_1 = create_duplets(xor_ciphered_strings)
duplets_2 = create_duplets(supposed_word.encode('utf-8').hex())


def get_xors(duplets_1, duplets_2):
    array = []
    for index in range(len(duplets_1) - len(duplets_2) + 1):
        answer = xor(duplets_1[index: index + len(duplets_2)], duplets_2)
        array.append(answer)
    return array

array = get_xors(duplets_1, duplets_2)

def get_result(array):
    result = []
    for string in array:
        result.append(bytearray.fromhex(string).decode())
    return result

print(get_result(array))
    
    
answer = """
For who would bear the whips and scorns of time,
Th'oppressor's wrong, the proud man's contumely,
The pangs of dispriz'd love, the law's delay,
The insolence of office, and the spurns
That patient merit of th'unworthy takes,
When he himself might his quietus make
With a bare bodkin? Who would fardels bear,
To grunt and sweat under a weary life,
But that the dread of something after death,
The undiscovere'd country, from whose bourn
No traveller returns, puzzles the will,
And makes us rather bear those ills we have
Than fly to others that we know not of?
Thus conscience doth make cowards of us all,
And thus the native hue of resolution
Is sicklied o'er with the pale cast of thought,
And enterprises of great pith and moment
With this regard their currents turn awry
And lose the name of action.
"""