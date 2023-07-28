<template>
    <form @submit.prevent="onSubmit">
        <input type="text" class="commentInput"/>
        <button type="submit">Add Comment</button>
    </form>
</template>

<script>
    export default {
        methods: {
            onSubmit() {
                if (this.title.trim()) {
                    const newComment = {
                        id: Date.now(),
                        title: this.title
                    }
                }

                this.$emit('add-comment', newComment)
            }
        }
    }
</script>

<style>
    .commentInput{
        width:300px;
        height:25px;
        border-radius:10px;
    }
    button {
        width: 120px;
        height: 25px;
        border-radius: 10px;
        
    }
</style>