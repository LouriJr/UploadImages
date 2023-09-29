import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import ImageSelector from './src/Components/ImageSelector';
import ImageList from './src/Components/ImageList';

export default function App() {
  return (
    <View style={styles.container}>
      <ImageSelector></ImageSelector>
      <ImageList></ImageList>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
