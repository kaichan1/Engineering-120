echo "Hello. This is a batch file."
if (get-item -path Text -erroraction ignore) {

} else {
    echo "Creating folder."
    md Text
}

cd Text
echo "Hello world." > Text.txt
cat Text.txt
del Text.txt
cd ..
del Text