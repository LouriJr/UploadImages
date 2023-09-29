import React, { useState } from 'react'
import * as ImagePicker from 'expo-image-picker';
import { Button, Image, Text, TextInput, View } from 'react-native';
import axios from 'axios';

export default function ImageSelector() {

    const [name, setName] = useState("");
    const [base64, setBase64] = useState("");

    async function selecionarImagem() {
        let result = await ImagePicker.launchImageLibraryAsync({
            mediaTypes: ImagePicker.MediaTypeOptions.Images,
            quality: 1,
        });

        if (result.canceled) {
            return;
        }
        setBase64(result.assets[0].uri);
    }

    async function Cadastrar() {
        const body = { name, base64 };
        const response = await axios.post("https://localhost:44363/api/image", body);
    }

    return (
        <View>
            <TextInput
                placeholder='Digite o nome'
                value={name}
                onChangeText={(texto) => setName(texto)}
            />
            <Button title="Selecione a imagem" onPress={selecionarImagem} />
            <Image source={{ uri: base64 }} style={{ width: 200, height: 200 }} />

            <Button title="Cadastrar" onPress={Cadastrar} />
        </View>
    )
}
