import { ref } from 'vue'
import axios from 'axios'
import { apiUrl } from '../ApiUrl'

interface DeleteUserResponseDto {
    success: boolean
}

export const useDeleteUser = () => {
    const deleteUserResponse = ref<DeleteUserResponseDto>({
        success: false
    })

    const deleteUser = async (id: number) => {
        const res = await axios.delete(`${apiUrl}/users/${id}`)
            .then(res => {
                deleteUserResponse.value = {
                    success: true
                }
                return deleteUserResponse.value
            })
            .catch(err => {
                alert(err.response.data.message)
                return {
                    success: false
                }
            })

        deleteUserResponse.value = res
    }

    return { deleteUserResponse, deleteUser }
}